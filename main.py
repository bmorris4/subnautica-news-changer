#make a bottle web server
from bottle import route, run, template, static_file, request, response
import os
import json
import time
import datetime
import sys
import subprocess
import threading

@route('/api/feedback/replies/user/<user>')
def get_feedback_replies(user):
    print(user)
    return json.dumps([])

@route('/api/log-settings')
def get_log_settings():
    return json.dumps({
    "session_log_resolution": 300,
    "category_settings": [
        True,
        True,
        True,
        True,
        False,
        True
    ],
    "statistics_period": 300
})

@route('/api/news/pc-new')
def get_news():
    return json.dumps([
    {
        "_id": "639906e313df172dcd080564",
        "platform": "pc",
        "header": "bmorris update",
        "read_more_url": "https://snupdates.s3.us-west-1.amazonaws.com/all/news/SN_Dec_22_LRGRM_ingamenews_500x500.png",
        "image_url": "https://snupdates.s3.us-west-1.amazonaws.com/all/news/SN_Dec_22_LRGRM_ingamenews_500x500.png",
        "text": "This is a custom subnautica server",
        "updated_at": "2022-12-13",
        "created_at": "2022-12-13"
    }
])

if __name__ == '__main__':
    run(host='localhost', port=3642, debug=True)