from selenium import webdriver
from webdriver_manager.chrome import ChromeDriverManager

def get_selenium_driver(browser):
  if (browser == 'chrome'):
    options = webdriver.ChromeOptions()
    options.add_argument('ignore-certificate-errors')
    return webdriver.Chrome(ChromeDriverManager().install(), chrome_options=options)