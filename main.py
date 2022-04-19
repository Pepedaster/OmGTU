import vk_api
from vk_api.keyboard import VkKeyboard, VkKeyboardColor
from vk_api.longpoll import VkLongPoll, VkEventType
from vk_api import VkUpload
import requests
import random

session = requests.Session()
vk_session = vk_api.VkApi(token='c95a56d6d6697e0a9bed6d175794647ec0bd579fd0cf462e250bed4b27e45f176e9045695af1dbc2cf3f5')
# задаем токен полученный в сообществе вк
longpoll = VkLongPoll(vk_session)  # задаем longpoll
vk = vk_session.get_api()

keyboard = VkKeyboard(one_time=False)
keyboard.add_button('Мотивашка', color=VkKeyboardColor.NEGATIVE)
keyboard.add_line()
keyboard.add_location_button()

upload = VkUpload(vk_session)
images_urls = []
images_urls.append('https://pressa.tv/uploads/posts/2016-11/1479926619_8cqnemrbo0g.jpg')
images_urls.append('https://pressa.tv/uploads/posts/2016-11/1479926625_8nctuyug5gs.jpg')
images_urls.append('https://pressa.tv/uploads/posts/2016-11/1479926663_8zasn6fxzie.jpg')
images_urls.append('https://pressa.tv/uploads/posts/2016-11/1479926625_9o3kem5eo64.jpg')
images_urls.append('https://pressa.tv/uploads/posts/2016-11/1479926685_a5lkgdydlng.jpg')
images_urls.append('https://pressa.tv/uploads/posts/2016-11/1479926624_dob-atssyo8.jpg')
images_urls.append('https://pressa.tv/uploads/posts/2016-11/1479926651_befacghlhjy.jpg')
images_urls.append('https://pressa.tv/uploads/posts/2016-11/1479926619_1egopvvkiug.jpg')

for event in longpoll.listen():  # Слушаем longpoll, если пришло сообщение то:
    if event.type == VkEventType.MESSAGE_NEW and event.to_me and event.text:

        if event.text == 'Привет':  # если написали привет ?
            if event.from_user:  # Если написали в ЛС?
                vk.messages.send(  # Отправляем сообщение
                    user_id=event.user_id,
                    random_id=event.random_id,
                    keyboard=keyboard.get_keyboard(),
                    message='И тебе привет'
                )

        if event.text == "Мотивашка":
            if event.from_user:
                attachments = []
                image = session.get(images_urls[random.randint(0, 7)], stream=True)
                photo = upload.photo_messages(photos=image.raw)[0]
                attachments.append(
                    'photo{}_{}'.format(photo['owner_id'], photo['id'])
                )

                vk.messages.send(
                    user_id=event.user_id,
                    random_id=event.random_id,
                    attachment=','.join(attachments)
                )
