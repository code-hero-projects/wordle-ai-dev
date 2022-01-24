from game.model.CorrectLetterPosition import CorrectLetterPosition
from game.model.LetterState import LetterState
from game.model.MisplacedLetterPosition import MisplacedLetterPosition

class GameState:
  def __init__(self) -> None:
      self.correct = []
      self.wrong = []
      self.misplaced = []
      self.tried = []
      self.correct_letters = 0
      self.letter_input_handlers = {
        LetterState.WRONG: self.wrong_letter_handler,
        LetterState.CORRECT: self.correct_letter_handler,
        LetterState.MISPLACED: self.misplaced_letter_handler
      }
    
  def update_state(self, letter_inputs, last_word):
    self.tried.append(last_word)

    for index, letter_input in enumerate(letter_inputs):
      letter = letter_input.letter
      result = letter_input.letter_state
      handler = self.letter_input_handlers[result]
      handler(letter, index)
    
    self.correct_letters = len(list(filter(lambda x: x.letter_state == LetterState.CORRECT, letter_inputs)))

  def correct_letter_handler(self, letter, index):
    already_correct = list(filter(lambda correct: correct.letter == letter, self.correct))
    if (len(already_correct) == 0):
      letter_position = CorrectLetterPosition(letter, index)
      self.correct.append(letter_position)

  def wrong_letter_handler(self, letter, index):
    already_correct = list(filter(lambda correct: correct.letter == letter, self.correct))
    if (len(already_correct) != 0):
      already_misplaced = list(filter(lambda misplaced: misplaced.letter == letter, self.misplaced))
      if (len(already_misplaced) == 0):
        misplaced = MisplacedLetterPosition(letter, [index])
        self.misplaced.append(misplaced)
      else:
        already_misplaced[0].positions_tried.append(index)
    else:
      self.wrong.append(letter)

  def misplaced_letter_handler(self, letter, index):
    already_misplaced = list(filter(lambda misplaced: misplaced.letter == letter, self.misplaced))
    if (len(already_misplaced) == 0):
      misplaced = MisplacedLetterPosition(letter, [index])
      self.misplaced.append(misplaced)
    else:
      already_misplaced[0].positions_tried.append(index)