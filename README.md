# Novafuria.DataIngester.Project <!-- omit in toc -->

***Proposal for a data ingestion system for multiple file systems focused on Temporal.io***

<div align="center">

&nbsp;

[![License: MIT](https://img.shields.io/badge/License-Private-yellow.svg)](./LICENSE)
[![Contributor covenant: 2.1](https://img.shields.io/badge/Contributor%20Covenant-2.1-4baaaa.svg)](./CODE_OF_CONDUCT.md)
[![Semantic Versioning: 2.0.0](https://img.shields.io/badge/Semantic--Versioning-2.0.0-a05f79?logo=semantic-release&logoColor=f97ff0)](https://semver.org/)

[![Labeling](https://github.com/mauroalderete/Novafuria.DataIngester.Project/actions/workflows/labeling.yml/badge.svg)](https://github.com/mauroalderete/Novafuria.DataIngester.Project/actions/workflows/labeling.yml)
[![Unit Tests](https://github.com/mauroalderete/Novafuria.DataIngester.Project/actions/workflows/tests.yml/badge.svg)](https://github.com/mauroalderete/Novafuria.DataIngester.Project/actions/workflows/unit-tests.yml)
[![CodeQL](https://github.com/mauroalderete/Novafuria.DataIngester.Project/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/mauroalderete/Novafuria.DataIngester.Project/actions/workflows/codeql-analysis.yml)
[![Liberation](https://github.com/mauroalderete/Novafuria.DataIngester.Project/actions/workflows/liberation.yml/badge.svg)](https://github.com/mauroalderete/Novafuria.DataIngester.Project/actions/workflows/liberation.yml)
[![Project Automation](https://github.com/mauroalderete/Novafuria.DataIngester.Project/actions/workflows/project-automation.yml/badge.svg)](https://github.com/mauroalderete/Novafuria.DataIngester.Project/actions/workflows/project-automation.yml)

[Bug Report](./issues/new?assignees=&labels=bug%2Clifecycle%2Fneeds-triage&projects=mauroalderete%2F20&template=1-bug-report.yml&title=...+is+broken)
⭕
[Feature Request](./issues/new?assignees=&labels=enhancement%2Clifecycle%2Fneeds-triage&projects=mauroalderete%2F20&template=2-feature-request.yml&title=As+a+%5Btype+of+user%5D%2C+I+want+%5Ba+goal%5D+so+that+%5Bbenefit%5D)
⭕
[Help Wanted](./issues/new?assignees=&labels=help+wanted%2Clifecycle%2Fneeds-triage&projects=mauroalderete%2F20&template=3-help-wanted.yml&title=I+need+help+with...)

[![Share on X](https://img.shields.io/twitter/url?label=Share%20on%20Twitter&style=social&url=https%3A%2F%2Fgithub.com%2Fatapas%2Fmodel-repo)](https://twitter.com/intent/tweet?text=👋%20Check%20this%20amazing%20repo%20https://github.com/mauroalderete/Novafuria.DataIngester.Project,%20created%20by%20@_mauroalderete%0A%0A%23DEVCommunity%20%23Coding%20%23Data)

&nbsp;

</div>

- [✋ Introducing `Novafuria.DataIngester.Projects`](#-introducing-novafuriadataingesterprojects)
- [Workflows](#workflows)
- [Contributing](#contributing)
- [Code of conduct](#code-of-conduct)
- [License](#license)

&nbsp;

## ✋ Introducing `Novafuria.DataIngester.Projects`

This repository is a proposal for a data ingestion system for multiple file systems focused on Temporal.io.

The project is a data ingestion system that allows you to ingest data from multiple file systems and maintain a history of the data ingested.

`Novafuria.DataIngester.Projects` is mounted on a .NET Core 8.0 framework and uses the `Kite Architecture` to manage layers based on some aspects from DDD and cleans Architecture principles. These provide a clean, scalable and heavy extensible solution.

Some implementations are focused on the `Temporal.io` framework, which allows you deploy each workflow as a microservice in a distributed environment.

You would like to contribute to the project, adding new extensions, or improving the existing ones, please read the [CONTRIBUTING.md](./CONTRIBUTING.md) file.

## Workflows

This repository contains several workflows to perform various tasks of testing, versioning, labeling, and deployment.

CodeQL is configured to analyze the code and identify potential security vulnerabilities each week.

Uses dependabot to keep your dependencies up to date.

## Contributing

When contributing to this repository, please first read the [CONTRIBUTING.md](./CONTRIBUTING.md) file, and then discuss the change you wish to make via issue.

## Code of conduct

`/CODE_OF_CONDUCT.md`

The [CODE_OF_CONDUCT.md](./CODE_OF_CONDUCT.md) file contains the covenant code of conduct.

## License

This repository is licensed under the MIT license. [LICENSE](./LICENSE)
