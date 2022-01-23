from pyshadow.main import Shadow
from game.model.LetterInput import LetterInput
from game.model.LetterState import LetterState
from utils.selenium_driver_factory import get_selenium_driver

class SeleniumWrapper:
  def __init__(self, url, browser) -> None:
      self.driver = get_selenium_driver(browser)
      self.driver.maximize_window()
      self.driver.get(url)
      self.driver = Shadow(self.driver)

      self.turn_tiles_mapper = { 0: (0, 5), 1: (5, 10), 2: (10, 15), 3: (15, 20), 4: (20, 25), 5: (25, 30) }
      self.letter_state_mapper = { 'absent': LetterState.WRONG, 'correct': LetterState.CORRECT, 'present': LetterState.MISPLACED }

  def get_last_input(self, turn):
    all_row_tiles = self.driver.find_elements("game-tile")
    (begin_tile_index, end_tile_index) = self.turn_tiles_mapper[turn]
    current_turn_tiles = all_row_tiles[begin_tile_index : end_tile_index]

    letter_inputs = []
    for tile in current_turn_tiles:
      letter = self.driver.get_attribute(tile, 'letter')
      evaluation = self.driver.get_attribute(tile, 'evaluation')
      letter_state = self.letter_state_mapper[evaluation]

      letter_input = LetterInput(letter, letter_state)
      letter_inputs.append(letter_input)

    return letter_inputs