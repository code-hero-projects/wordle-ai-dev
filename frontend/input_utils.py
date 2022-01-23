from config import MODAL_POSITION
import pyautogui

def close_modal():
  (x, y) = MODAL_POSITION
  pyautogui.click(x, y)

def press_key(letter):
  pyautogui.press(letter)

def press_enter():
  pyautogui.press('enter')