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

  # def press_key(self, letter):
  #   keyboards_rows = self.driver.get_child_elements(self.keyboard)
    
  #   for keyboard_row in keyboards_rows:
  #     keys = keyboard_row.get_child_elements(keyboard_row)
  #     for key in keys:
  #       if (key.text == letter):
  #         key.click()
  #         return