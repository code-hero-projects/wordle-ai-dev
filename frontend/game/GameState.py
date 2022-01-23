from game.CorrectLetterPosition import CorrectLetterPosition
from game.LetterState import LetterState
from game.MisplacedLetterPosition import MisplacedLetterPosition

class GameState:
  def __init__(self) -> None:
      self.correct = []
      self.wrong = []
      self.misplaced = []
      self.tried = []
    
  def update_state(self, letter_inputs, last_word):
    self.tried.append(last_word)

    for index, letter_input in enumerate(letter_inputs):
      letter = letter_input.letter
      result = letter_input.letter_state

      if (result == LetterState.WRONG):
        self.wrong.append(letter)
      elif (result == LetterState.CORRECT):
        letter_position = CorrectLetterPosition(letter, index)
        self.correct.append(letter_position)
      else:
        already_misplaced = list(filter(lambda misplaced: misplaced.letter == letter, self.misplaced))
        if (len(already_misplaced) == 0):
          misplaced = MisplacedLetterPosition(letter, [index])
          self.misplaced.append(misplaced)
        else:
          already_misplaced[0].positions_tried.append(index)