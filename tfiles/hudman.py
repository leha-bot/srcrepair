#!/usr/bin/env python3
# coding=utf-8

#
# Скрипт создания и обновления зеркала HUD.
#
# Copyright 2011 - 2016 EasyCoding Team (ECTeam).
# Copyright 2005 - 2016 EasyCoding Team.
#
# Лицензия: GPL v3 (см. файл GPL.txt).
# Лицензия контента: Creative Commons 3.0 BY.
#
# Запрещается использовать этот файл при использовании любой
# лицензии, отличной от GNU GPL версии 3 и с ней совместимой.
#
# Официальный блог EasyCoding Team: http://www.easycoding.org/
# Официальная страница проекта: http://www.easycoding.org/projects/srcrepair
#
# Более подробная инфорация о программе в readme.txt,
# о лицензии - в GPL.txt.
#
import urllib, json, os, time
from xml.dom import minidom
from datetime import datetime


def parsedb(dbname):
    # Creating list for result...
    result = []

    # Opening HUD database...
    huddb = minidom.parse(dbname)

    # Parsing...
    for hud in huddb.getElementsByTagName('HUD'):
        result.append([hud.getElementsByTagName("Name")[0].firstChild.data,
                       hud.getElementsByTagName("UpURI")[0].firstChild.data,
                       hud.getElementsByTagName("RepoPath")[0].firstChild.data,
                       int(hud.getElementsByTagName("LastUpdate")[0].firstChild.data)])

    # Returning result...
    return result


def gmt2unix(gtime):
    do = datetime.strptime(gtime, '%Y-%m-%dT%H:%M:%SZ')
    return int(time.mktime(do.timetuple()))


def getghinfo(repourl):
    url = repourl.replace('https://github.com/', 'https://api.github.com/repos/') + '/commits?per_page=1'
    response = urllib.urlopen(url).read()
    data = json.loads(response.decode())
    return [data[0]['sha'], gmt2unix(data[0]['commit']['committer']['date'])]


def downloadfile(url, name):
    dir = os.path.join(os.getcwd(), name)
    if not os.path.exists(dir):
        os.makedirs(dir)
    filepath = os.path.join(dir, '%s.zip' % name)
    urllib.urlretrieve(url, filepath)
    return filepath


def renamefile(fname, chash):
    dir = os.path.dirname(fname)
    result = os.path.join(dir, '%s_%s.zip' % (os.path.splitext(os.path.basename(fname))[0], chash[:8]))
    os.rename(fname, result)
    return result


def handlehud(name, url, repo, ltime):
    if repo.find('https://github.com/') != -1:
        r = getghinfo(repo)
        if r[1] > ltime:
            f = renamefile(downloadfile(url, name), r[0])
            print('Available: %s, hash: %s, filename: %s.' % (name, r[0], f))
        else:
            print('%s is actual.' % name)
    else:
        print('%s not from GH' % name)


def main():
    try:
        # Main exec...
        huddb = parsedb('huds.xml')

        for hud in huddb:
            handlehud(hud[0], hud[1], hud[2], hud[3])

    except:
        # Exception detected...
        print('An error occurred. Try again later.')


if __name__ == '__main__':
    main()
