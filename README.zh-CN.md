# 企业运营管理桌面客户端（二次开发版）

这是一个面向企业内部运营场景的 C# 全栈学习项目，由 WPF 桌面客户端和 ASP.NET Core Web API 组成。客户端采用 MVVM 模式，通过 RESTful API 完成业务数据维护；服务端使用 EF Core 与 SQL Server 持久化数据。

> 本项目属于开源二次开发作品，来源与新增内容见 [NOTICE.md](NOTICE.md)，并非从零独立原创。

## 技术栈

- C#、.NET 8、WPF、MVVM
- ASP.NET Core Web API、Swagger
- Entity Framework Core、SQL Server
- xUnit、AutoMapper、依赖注入

## 已有功能

- 桌面端业务数据查询、新增、编辑与删除
- 客户和资产的多对多关系维护
- RESTful API、Swagger 接口文档与单元测试
- 运营驾驶舱汇总接口：`GET /api/operations-dashboard/summary`
- 服务健康检查：`GET /health`

## 目录结构

- `VesselManagementClient`：WPF 桌面客户端与 MVVM 视图模型
- `VesselManagementApi`：Web API、服务层、数据访问及 DTO
- `VesselManagementApi.Tests`：控制器单元测试
- `Database`：数据库初始化脚本

## 本地运行

1. 安装 .NET 8 SDK、Visual Studio 2022 与 SQL Server。
2. 修改 `VesselManagementApi/appsettings.json` 中的数据库连接字符串。
3. 运行 Web API，并通过 Swagger 检查接口。
4. 启动 WPF 客户端，确认其 API 地址指向本地服务。

请勿向仓库提交真实数据库密码、访问令牌或生产环境配置。
