class GameState:
  def __init__(self) -> None:
      self.correct = []
      self.wrong = []
      self.misplaced = []
      self.tried = []
    
  def update_state(self, letter_inputs, last_word):
    pass