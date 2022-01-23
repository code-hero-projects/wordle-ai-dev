class PostRequestBody:
  def __init__(self, game_state) -> None:
    self.correct = game_state.correct
    self.wrong = game_state.wrong
    self.misplaced = list(map(lambda x: MisplacedLetterPositionRequest(x.letter, x.positions_tried), game_state.misplaced))
    self.tried = game_state.tried

class MisplacedLetterPositionRequest:
  def __init__(self, letter, positions_tried) -> None:
      self.letter = letter
      self.positionsTried = positions_tried
