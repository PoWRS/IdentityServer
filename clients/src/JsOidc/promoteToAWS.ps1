docker build ./ -f ./Dockerfile -t newspaper:latest
docker tag newspaper:latest 548668861663.dkr.ecr.us-east-2.amazonaws.com/newspaper
docker push 548668861663.dkr.ecr.us-east-2.amazonaws.com/newspaper