FROM node:24-alpine

WORKDIR /app

COPY package.json package-lock.json ./

RUN npm ci --silent

COPY . .

ARG NEXT_PUBLIC_API_URL
ENV NEXT_PUBLIC_API_URL=$NEXT_PUBLIC_API_URL

RUN npm run build

EXPOSE 3000

CMD ["npm", "start"]
