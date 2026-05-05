#!/bin/bash

read -p "Add meg a file nevét: " file

result=$(cut -d' ' -f 2 $file)

echo $result
