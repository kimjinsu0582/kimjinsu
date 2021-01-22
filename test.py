from os.path import getsize
import sys
import argparse
import os
import struct

LF_offset=[]
offset=0
f = open("testfile.zip",'rb')
fSize=getsize('testfile.zip')

while offset<fSize:
    f.seek(offset)
    r=f.read(4)
    if r == ('\x50\x4B\x03\x04').encode('utf-8') :
        LF_offset.append(offset)
    elif r == ('\x50\x4B\x01\x02').encode('utf-8') :
        CF_start_offset = offset
        break
    offset +=1



import struct
def little2(hex) :
    return struct.unpack('<H', hex)[0]

name = []
Data = []
for i in range(len(LF_offset)) :

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

dataLen = LF_offset[1] - Data[0]
f.seek(Data[0])
data_area1 = f.read(dataLen)

dataLens = CF_start_offset - Data[1]
f.seek(Data[1])
data_area2 = f.read(dataLens)


fw = open(name[0], 'wb')
fw.write(data_area1)
fw.close()
