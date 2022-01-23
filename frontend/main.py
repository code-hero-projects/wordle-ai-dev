import time
from config import *
from game.Game import Game
from utils.SeleniumWrapper import SeleniumWrapper
from utils.input_utils import close_modal
from api.WordleAIApi import WordleAIApi

def main():
  selenium_wrapper = SeleniumWrapper(WORDLE_URL)
  word_api = WordleAIApi(API_URL)

  time.sleep(2)
  close_modal()

  game = Game(selenium_wrapper, word_api, FIRST_WORD, SLEEP_AFTER_WORD_IN_SECONDS, SLEEP_AFTER_END_GAME_IN_SECCONDS)
  game.play()

if __name__ == '__main__':
  main()