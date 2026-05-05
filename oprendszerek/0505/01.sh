#!/bin/bash

read -p "Mappa neve: " folder

if [ ! -d "$folder" ]; then
  echo "Nem létező mappa!"
  exit 1
fi

ls -l --sort=time $folder
