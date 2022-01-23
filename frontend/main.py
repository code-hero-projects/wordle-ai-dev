import time
from config import WORDLE_URL
from SeleniumWrapper import SeleniumWrapper

selenium_wrapper = SeleniumWrapper(WORDLE_URL)
# selenium_wrapper.press_key('g')

time.sleep(3)