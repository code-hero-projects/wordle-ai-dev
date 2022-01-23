import time
from config import *
from SeleniumWrapper import SeleniumWrapper
from input_utils import close_modal, press_key

selenium_wrapper = SeleniumWrapper(WORDLE_URL)

close_modal()

# for letter in 'adieu':
#   press_key(letter)