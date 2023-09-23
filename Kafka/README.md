# Kafka
## 概要
Kafkaは、分散ストリーミングプラットフォームです。Kafkaは、ストリームデータを高速にパブリッシュ、サブスクライブ、ストアすることができます。Kafkaは、ストリームデータを高速にパブリッシュ、サブスクライブ、ストアすることができます。Kafkaは、ストリームデータを高速にパブリッシュ、サブスクライブ、ストアすることができます。Kafkaは、ストリームデータを高速にパブリッシュ、サブスクライブ、ストアすることができます。Kafkaは、ストリームデータを高速にパブリッシュ、サブスクライブ、ストアすることができます。Kafkaは、ストリームデータを高速にパブリッシュ、サブスクライブ、ストアすることができます。Kafkaは、ストリームデータを高速にパブリッシュ、サブスクライブ、ストアすることができます。
## Kafkaの構成
Kafkaは、以下の3つの要素で構成されています。
* Producer: メッセージを送信するアプリケーション
* Consumer: メッセージを受信するアプリケーション
* Broker: メッセージを受信し、ProducerからConsumerへメッセージを配信するサーバー
## Kafkaの特徴
1. ***高スループット***: Kafkaは高いスループットを持っており、一秒あたりに数百万件のメッセージを処理することができます。
1. ***スケーラビリティ***: Kafkaは水平スケーリングが可能であり、クラスター内のノード数を増やすことで容量やスループットを簡単に増加させることができます。
1. ***デュラビリティと信頼性***: データは分散されたサーバーに保存され、レプリケーションによってデータロスのリスクが軽減されます。
1. ***順序保証***: 一つのパーティション内でのメッセージの順序は保証されます。
1. ***低レイテンシ***: リアルタイムのデータ処理が可能です。
1. ***フルトレント***: 既存のデータを保存しながら新しいデータをリアルタイムで処理することができます。
1. ***プロデューサーとコンシューマの分離***: データの生成（プロデューサー）とデータの消費（コンシューマ）は独立しており、それぞれが異なるペースで動作することができます。
1. ***多機能なクエリ言語***: Kafka自体はデータのストレージと転送に特化していますが、KSQLやKafka Streamsのようなツールを用いることで、データのストリーミング処理やリアルタイムの分析も可能です。
# Zookeeper
## 概要
Zookeeperは、分散アプリケーションのための分散コンフィグレーションサービスです。Zookeeperは、分散アプリケーションのための分散コンフィグレーションサービスです。Zookeeperは、分散アプリケーションのための分散コンフィグレーションサービスです。Zookeeperは、分散アプリケーションのための分散コンフィグレーションサービスです。Zookeeperは、分散アプリケーションのための分散コンフィグレーションサービスです。Zookeeperは、分散アプリケーションのための分散コンフィグレーションサービスです。Zookeeperは、分散アプリケーションのための分散コンフィグレーションサービスです。
## Zookeeperの構成
Zookeeperは、以下の3つの要素で構成されています。
* Leader: Zookeeperクラスターの中で、クライアントからのリクエストを受け付ける役割を持つノード
* Follower: Zookeeperクラスターの中で、Leaderからのリクエストを受け付ける役割を持つノード
* Observer: Zookeeperクラスターの中で、リーダーからのリクエストを受け付ける役割を持つノード
## Zookeeperの特徴
1. ***高可用性***: Zookeeperは、複数のノードで構成されており、ノードの一部がダウンしてもサービスを継続することができます。
1. ***耐障害性***: Zookeeperは、複数のノードで構成されており、ノードの一部がダウンしてもサービスを継続することができます。
1. ***一貫性***: Zookeeperは、複数のノードで構成されており、ノードの一部がダウンしてもサービスを継続することができます。
1. ***スケーラビリティ***: Zookeeperは、複数のノードで構成されており、ノードの一部がダウンしてもサービスを継続することができます。
1. ***シンプルなAPI***: Zookeeperは、複数のノードで構成されており、ノードの一部がダウンしてもサービスを継続することができます。
1. ***高性能***: Zookeeperは、複数のノードで構成されており、ノードの一部がダウンしてもサービスを継続することができます。
1. ***軽量***: Zookeeperは、複数のノードで構成されており、ノードの一部がダウンしてもサービスを継続することができます。
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
kafka-console-consumer --bootstrap-server localhost:9092 --topic test-topic --from-beginning

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
# TODO
色々と諦めた、
* コンシュマーが動作しなかった。
* PrometheusとGrafanaでメトリクスを取得することができなかった。
