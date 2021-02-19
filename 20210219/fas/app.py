from os.path import getsize
import sys
import argparse
import os
import struct
import zlib
LF_offset = []
offset = 0
f = open("ppt1.zip", 'rb')
fSize = getsize('ppt1.zip')

while offset < fSize:
    f.seek(offset)
    r = f.read(4)
    if r == ('\x50\x4B\x03\x04').encode('utf-8'):
        LF_offset.append(offset)
    elif r == ('\x50\x4B\x01\x02').encode('utf-8'):
        CF_start_offset = offset
        break
    offset += 1

import struct


def little2(hex):
    return struct.unpack('<H', hex)[0]


name = []
Data = []
for i in range(len(LF_offset)):
    name_length_offset = LF_offset[i] + 26
    f.seek(name_length_offset)
    nameLen_hex = f.read(2)
    nameLen = little2(nameLen_hex)

    Extra_Length_offset = name_length_offset + 2
    f.seek(Extra_Length_offset)
    ExtraLen_hex = f.read(2)
    ExtraLen = little2(ExtraLen_hex)

    name_offset = Extra_Length_offset + 2
    f.seek(name_offset)
    name_hex = f.read(nameLen)
    name.append(name_hex.decode())

    Data_offset = name_offset + nameLen + ExtraLen
    Data.append(Data_offset)


print('File name :', name)
print('Data offset :', Data)

dataLen = []
for i in range(len(Data)):
    if i == len(Data) - 1:
        dataLen.append(CF_start_offset - Data[i])
    else:
        dataLen.append(LF_offset[i + 1] - Data[i])

print('DataLen', dataLen)


def xmldata(Data, dataLen):
    f.seek(Data)
    data = f.read(dataLen)
    data = zlib.decompress(data, -zlib.MAX_WBITS)
    data = data.decode("utf-8", "ignore")
    return data


app_data_offset = 553709
app_dataLen = 593

app_data = xmldata(app_data_offset, app_dataLen)

print('app data :', app_data)

x = app_data.find("<Paragraphs>")
m = app_data.find("</Paragraphs")
len('<Paragraphs>')

print(len('<Paragraphs>'))
print(app_data[x + 12:m])

