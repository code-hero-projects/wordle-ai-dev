import pyautogui

class PyAutoGuiWrapper:
  def __init__(self) -> None:
      pass

  def close_modal(self):
    pyautogui.click()

  def write_word(self, word):
    for letter in word:
      pyautogui.press(letter)
    pyautogui.press('enter')
