from selenium import webdriver
from webdriver_manager.chrome import ChromeDriverManager
from pyshadow.main import Shadow

class SeleniumWrapper:
  def __init__(self, url) -> None:
      self.driver = webdriver.Chrome(ChromeDriverManager().install())
      self.driver.maximize_window()
      self.driver.get(url)
      self.driver = Shadow(self.driver)

      self.keyboard = self.driver.find_element('div#keyboard')

  def close_modal(self):
    close_icon = self.driver.find_element("game-modal[open='']")
    print(close_icon)
    close_icon.click()

  def press_key(self, letter):
    keyboards_rows = self.driver.get_child_elements(self.keyboard)
    for keyboard_row in keyboards_rows:
      keys = self.driver.get_child_elements(keyboard_row)
      for key in keys:
        if (key.text == letter.upper()):
          key.click()
          return