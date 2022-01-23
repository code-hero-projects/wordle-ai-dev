import requests

class ApiWordSupplier:
  def __init__(self, url) -> None:
      self.word = url
  
  def get_word(self, game_state):
    payload = {
      'correct': game_state.correct,
      'wrong': game_state.wrong,
      'misplaced': game_state.misplaced,
      'tried': game_state.tried
    }

    response = requests.post(self.url, data = payload)
    return response.recommendedWord