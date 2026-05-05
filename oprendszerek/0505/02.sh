#!/bin/bash

while true; do

  read -p "Adj meg a fájl nevet: " file

  if [ ! -f "$file" ]; then
    echo "Nem létező file"
    exit 1
  fi

  db=$(wc -l $file)

  echo "A sorok száma: ${db}"
done
