from bs4 import BeautifulSoup
import requests

textForSave = open("text.txt", 'w',encoding="utf-8")
url = 'https://omsk.drom.ru/auto/'
page = requests.get(url)
print(page.status_code)
soup = BeautifulSoup(page.text, "html.parser")

block = soup.findAll('a', {'class': 'css-eii4kh ewrty961'})
info = ''

for data in block:
    st = ''
    if data.find('span', {'data-ftid': 'bull_title'}):
        a = data.find('span',{'data-ftid': 'bull_title'})
        st = st + a.text
    if data.find('span', {'data-ftid': 'bull_price'}):
        a = data.find('span', {'data-ftid': 'bull_price'})
        st = st + ' ' + a.text
    info = info + st + '\n'

print(info)
textForSave.write(info)