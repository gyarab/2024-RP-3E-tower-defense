FROM nginx:alpine

WORKDIR /etc/nginx/conf.d
COPY nginx.conf default.conf

WORKDIR /etc/nginx/html
COPY Build/ .