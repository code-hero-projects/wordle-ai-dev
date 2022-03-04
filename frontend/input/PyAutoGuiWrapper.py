import pyautogui

class PyAutoGuiWrapper:
  def __init__(self) -> None:
      pass

  def click(self, x, y):
    pyautogui.click(x, y)
  
  def zoom(self):
    pyautogui.hotkey('ctrl', '+')

  def write_word(self, word):
    for letter in word:
      pyautogui.press(letter)
    pyautogui.press('enter')
