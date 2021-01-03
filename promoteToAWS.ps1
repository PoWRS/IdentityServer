docker build ./ -f ./Dockerfile -t sublessidentity:latest
docker tag sublessidentity:latest 548668861663.dkr.ecr.us-east-2.amazonaws.com/sublessidentity
docker push 548668861663.dkr.ecr.us-east-2.amazonaws.com/sublessidentity