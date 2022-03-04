import time
from config import *
from game.Game import Game
from input.PyAutoGuiWrapper import PyAutoGuiWrapper
from dom.SeleniumWrapper import SeleniumWrapper
from api.WordleAIApi import WordleAIApi

def main():
  input_wrapper = PyAutoGuiWrapper()
  dom_wrapper = SeleniumWrapper(WORDLE_URL, BROWSER, input_wrapper)
  word_api = WordleAIApi(API_URL)

  time.sleep(7)

  game = Game(dom_wrapper, word_api, input_wrapper, FIRST_WORD, SLEEP_AFTER_WORD_IN_SECONDS, SLEEP_AFTER_END_GAME_IN_SECCONDS)
  game.play()

if __name__ == '__main__':
  main()