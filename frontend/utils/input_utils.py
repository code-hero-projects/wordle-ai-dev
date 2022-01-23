import time
import pyautogui
from config import MODAL_POSITION

def close_modal():
  (x, y) = MODAL_POSITION
  time.sleep(1)
  pyautogui.click(x, y)

def write_word(word):
  for letter in word:
    pyautogui.press(letter)
  pyautogui.press('enter')
