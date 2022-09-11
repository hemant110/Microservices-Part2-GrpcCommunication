# Microservices-Part2-GrpcCommunication
Microservices Part2 - Microservice example with synchronous communication between services using GRPC
This application contains 2 API which communicates with each other synchronously by using Grpc.

Grpc refers to Google remote procedure calls, which uses proto files to describe and identify the service methods.

Grpc works in client and server architecture mode, where in 1 service acts as client and other as server. The clients calls the server.

Here, OrderService is our Grpc client API service and QualityCheck is our server API service.

Things to note while using Grpc message-
1) Grpc creates the class of you message and fields inside your messages becomes the properties.
2) It makes the first letter of you field to uppercase i.e. orderId will become OrderId.
3) If there are underscores in your field then those underscores will be removed and first letter will be capatilized after the underscore,
i.e. Order_code will become OrderCode.
