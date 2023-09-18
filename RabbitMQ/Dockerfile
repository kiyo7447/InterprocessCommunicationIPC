# RabbitMQをDockerで実行するための基本的なDockerfileを以下に示します。
# ただし、実際には、公式のRabbitMQイメージを使用する方が一般的です。

# 基本イメージ
FROM rabbitmq:3-management

# 管理ユーザー設定（オプション）
ENV RABBITMQ_DEFAULT_USER=admin
ENV RABBITMQ_DEFAULT_PASS=admin

# ポートを公開
EXPOSE 5672 15672
