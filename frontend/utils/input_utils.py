import pyautogui

def close_modal():
  pyautogui.click()

def write_word(word):
  for letter in word:
    pyautogui.press(letter)
  pyautogui.press('enter')
