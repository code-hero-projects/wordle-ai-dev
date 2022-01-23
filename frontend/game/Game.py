import time
from game.GameState import GameState
from utils.input_utils import write_word

class Game:
  def __init__(self, selenium_wrapper, word_api, first_word, word_writing_sleep, end_game_sleep) -> None:
      self.selenium_wrapper = selenium_wrapper
      self.word_api = word_api
      self.first_word = first_word
      self.word_writing_sleep = word_writing_sleep
      self.end_game_sleep = end_game_sleep
      self.game_state = GameState()
  
  def play(self):
    self.play_turn(0, self.first_word, self.game_state, self.selenium_wrapper)

    for i in range(1, 6):
      suggested_words = self.word_api.get_word(self.game_state)
      recommended_word = suggested_words.recommended_word

      if (len(suggested_words.filtered_words) == 1):
        write_word(recommended_word)
        time.sleep(self.end_game_sleep)
        break

      self.play_turn(i, recommended_word, self.game_state, self.selenium_wrapper)

  def play_turn(self, turn, word, game_state, selenium_wrapper):
    write_word(word)

    time.sleep(self.word_writing_sleep)
    
    last_input = selenium_wrapper.get_last_input(turn)
    game_state.update_state(last_input, word)