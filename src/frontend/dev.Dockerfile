FROM node:11.1.0-alpine AS node_base

FROM node_base as deps
WORKDIR /usr/app
COPY package.json /usr/app/package.json
COPY yarn.lock /usr/app/yarn.lock
RUN yarn install

FROM node_base as dev
WORKDIR /usr/app
COPY --from=deps /usr/app/node_modules /usr/app/node_modules
COPY --from=deps /usr/app/package.json /usr/app/
COPY --from=deps /usr/app/yarn.lock /usr/app/
ENTRYPOINT ["yarn", "run", "start"]