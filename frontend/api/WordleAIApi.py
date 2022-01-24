import requests
from api.json_converter import from_json, to_json
from game.model.SuggestedWords import SuggestedWords

from api.PostRequestBody import PostRequestBody

class WordleAIApi:
  def __init__(self, url) -> None:
      self.url = url
  
  def get_word(self, game_state):
    post_body = PostRequestBody(game_state)
    json_payload = to_json(post_body)

    headers = {'Content-Type': 'application/json'}
    response = requests.post(self.url, data = json_payload, headers = headers)
    json_response = from_json(response.text)

    return SuggestedWords(json_response['recommendedWord'], json_response['words'])