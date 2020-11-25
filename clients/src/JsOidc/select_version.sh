#!/bin/bash

if [ $site_version ]
then
  cp ./wwwroot/index2.html ./wwwroot/index.html
  echo changed the thing
else
  echo not changing the thing
fi
