

# 実行方法
## Kafkaの起動
```powershell
docker-compose up -d


```
## プロジェクトの作成
プロデューサーを作成する
```powershell
dotnet new console -n KafkaProducer
cd KafkaProducer
dotnet add package Confluent.Kafka --version 1.8.2

# ここでコーディングする

dotnet build
dounet run
```
コンシュマーの作成する
```powershell
dotnet new console -n KafkaConsumer
cd KafkaConsumer
dotnet add package Confluent.Kafka --version 1.8.2

# ここでコーディングする

dotnet build
dotnet run
```
## Kafkaデータの確認
Kafkaコンシューマーの利用: Kafka自体が提供するコンシューマーコマンドを使用して、データを読み出すことができます
```powershell
docker ps
# docker exec -it [KafkaコンテナのIDまたは名前] /bin/bash
docker exec -it c8d34d0acb3f /bin/bash
#kafka-console-consumer --bootstrap-server localhost:9092 --topic [トピック名] --from-beginning
kafka-console-consumer --bootstrap-server localhost:9092 --topic test_group --from-beginning
```
Kafkaトピックの確認: Kafka自体が提供するトピックコマンドを使用して、トピックを確認することができます
```powershell
docker exec -it c8d34d0acb3f /bin/bash
#kafka-topics --list --bootstrap-server localhost:9092
kafka-topics --list --bootstrap-server localhost:9092
```
Kafkaトピックの削除: Kafka自体が提供するトピックコマンドを使用して、トピックを削除することができます
```powershell
docker exec -it c8d34d0acb3f /bin/bash
#kafka-topics --delete --bootstrap-server localhost:9092 --topic [トピック名]
kafka-topics --delete --bootstrap-server localhost:9092 --topic test_group
```
Kafkaトピックの作成: Kafka自体が提供するトピックコマンドを使用して、トピックを作成することができます
```powershell
docker exec -it c8d34d0acb3f /bin/bash
#kafka-topics --create --bootstrap-server localhost:9092 --replication-factor 1 --partitions 1 --topic [トピック名]
kafka-topics --create --bootstrap-server localhost:9092 --replication-factor 1 --partitions 1 --topic test_group
```
Kafkaトピックの詳細確認: Kafka自体が提供するトピックコマンドを使用して、トピックの詳細を確認することができます
```powershell
docker exec -it c8d34d0acb3f /bin/bash
#kafka-topics --describe --bootstrap-server localhost:9092 --topic [トピック名]
kafka-topics --describe --bootstrap-server localhost:9092 --topic test_group
```
