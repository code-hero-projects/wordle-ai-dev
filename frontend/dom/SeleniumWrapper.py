import time
from pyshadow.main import Shadow
from game.model.LetterInput import LetterInput
from game.model.LetterState import LetterState
from dom.selenium_driver_factory import get_selenium_driver

class SeleniumWrapper:
  def __init__(self, url, browser, input_wrapper) -> None:
    self.driver = get_selenium_driver(browser)
    self.driver.maximize_window()
    self.driver.get(url)
    self.driver = Shadow(self.driver)
    self.input_wrapper = input_wrapper

    self.turn_tiles_mapper = { 0: (0, 5), 1: (5, 10), 2: (10, 15), 3: (15, 20), 4: (20, 25), 5: (25, 30) }
    self.letter_state_mapper = { 'absent': LetterState.WRONG, 'correct': LetterState.CORRECT, 'present': LetterState.MISPLACED }
    self._setup_window()

  def get_last_input(self, turn):
    all_row_tiles = self.driver.find_elements(".Tile-module_tile__UWEHN")
    (begin_tile_index, end_tile_index) = self.turn_tiles_mapper[turn]
    current_turn_tiles = all_row_tiles[begin_tile_index : end_tile_index]

    letter_inputs = []
    for tile in current_turn_tiles:
      aria_label = self.driver.get_attribute(tile, 'aria-label')
      letter = aria_label[0:1]
      evaluation = aria_label[2:]
      letter_state = self.letter_state_mapper[evaluation]

      letter_input = LetterInput(letter, letter_state)
      letter_inputs.append(letter_input)

    return letter_inputs
  
  def _setup_window(self):
    for i in range(5):
      self.input_wrapper.zoom()
    self.input_wrapper.click(2000, 1200)
    self.input_wrapper.click(2000, 500)
    time.sleep(1)
    self.input_wrapper.click(2500, 150)
    time.sleep(1)
    self.input_wrapper.click(1700, 580)
    time.sleep(1)
    self.input_wrapper.click(1700, 470)
    time.sleep(1)
    self.input_wrapper.click(1700, 370)
    time.sleep(1)
    self.input_wrapper.click(1850, 370)
    time.sleep(1)
    self.input_wrapper.fullscreen()