import time
from game.GameState import GameState

class Game:
  def __init__(self, dom_wrapper, word_api, input_wrapper, first_word, word_writing_sleep, end_game_sleep) -> None:
      self.dom_wrapper = dom_wrapper
      self.word_api = word_api
      self.input_wrapper = input_wrapper
      self.first_word = first_word
      self.word_writing_sleep = word_writing_sleep
      self.end_game_sleep = end_game_sleep
      self.game_state = GameState()
  
  def play(self):
    self.play_turn(0, self.first_word, self.game_state, self.dom_wrapper)

    for i in range(1, 6):
      suggested_words = self.word_api.get_word(self.game_state)
      recommended_word = suggested_words.recommended_word
      self.play_turn(i, recommended_word, self.game_state, self.dom_wrapper)
      
      if (self.game_state.correct_letters == 5):
        time.sleep(self.end_game_sleep)
        break

  def play_turn(self, turn, word, game_state, dom_wrapper):
    self.input_wrapper.write_word(word)

    time.sleep(self.word_writing_sleep)
    
    last_input = dom_wrapper.get_last_input(turn)
    game_state.update_state(last_input, word)