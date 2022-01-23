from email.mime import audio
import time
from config import *
from utils.SeleniumWrapper import SeleniumWrapper
from utils.input_utils import close_modal, write_word
from game.GameState import GameState
from api.ApiWordSupplier import ApiWordSupplier

def main():
  selenium_wrapper = SeleniumWrapper(WORDLE_URL)
  game_state = GameState()
  word_supplier = ApiWordSupplier(API_URL)

  time.sleep(5)
  close_modal()
  play_turn(0, FIRST_WORD, game_state, selenium_wrapper)

  for i in range(1, 6):
    suggested_words = word_supplier.get_word(game_state)
    play_turn(i, suggested_words.recommended_word, game_state, selenium_wrapper)

def play_turn(turn, word, game_state, selenium_wrapper):
  write_word(word)

  time.sleep(SLEEP_AFTER_WORD_IN_SECONDS)
  
  last_input = selenium_wrapper.get_last_input(turn)
  game_state.update_state(last_input, word)

if __name__ == '__main__':
  main()