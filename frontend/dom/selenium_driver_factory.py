from selenium import webdriver
from webdriver_manager.chrome import ChromeDriverManager

def get_selenium_driver(browser):
  if (browser == 'chrome'):
    return webdriver.Chrome(ChromeDriverManager().install())