# coding-projects-template <!-- omit in toc -->

***Template to coding projects that requires a conventional workflow***

<div align="center">

&nbsp;

[![License: MIT](https://img.shields.io/badge/License-Private-yellow.svg)](./LICENSE)
[![Contributor covenant: 2.1](https://img.shields.io/badge/Contributor%20Covenant-2.1-4baaaa.svg)](./CODE_OF_CONDUCT.md)
[![Semantic Versioning: 2.0.0](https://img.shields.io/badge/Semantic--Versioning-2.0.0-a05f79?logo=semantic-release&logoColor=f97ff0)](https://semver.org/)

[![Labeling](https://github.com/mauroalderete/coding-projects-template/actions/workflows/labeling.yml/badge.svg)](https://github.com/mauroalderete/coding-projects-template/actions/workflows/labeling.yml)
[![Tests](https://github.com/mauroalderete/coding-projects-template/actions/workflows/tests.yml/badge.svg)](https://github.com/mauroalderete/coding-projects-template/actions/workflows/tests.yml)
[![CodeQL](https://github.com/mauroalderete/coding-projects-template/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/mauroalderete/coding-projects-template/actions/workflows/codeql-analysis.yml)
[![Liberation](https://github.com/mauroalderete/coding-projects-template/actions/workflows/liberation.yml/badge.svg)](https://github.com/mauroalderete/coding-projects-template/actions/workflows/liberation.yml)
[![Deploy Release](https://github.com/mauroalderete/coding-projects-template/actions/workflows/deploy-release.yml/badge.svg)](https://github.com/mauroalderete/coding-projects-template/actions/workflows/deploy-release.yml)
[![Project Automation](https://github.com/mauroalderete/coding-projects-template/actions/workflows/project-automation.yml/badge.svg)](https://github.com/mauroalderete/coding-projects-template/actions/workflows/project-automation.yml)

[Bug Report](./issues/new?assignees=&labels=bug%2Clifecycle%2Fneeds-triage&projects=mauroalderete%2F20&template=1-bug-report.yml&title=...+is+broken)
⭕
[Feature Request](./issues/new?assignees=&labels=enhancement%2Clifecycle%2Fneeds-triage&projects=mauroalderete%2F20&template=2-feature-request.yml&title=As+a+%5Btype+of+user%5D%2C+I+want+%5Ba+goal%5D+so+that+%5Bbenefit%5D)
⭕
[Help Wanted](./issues/new?assignees=&labels=help+wanted%2Clifecycle%2Fneeds-triage&projects=mauroalderete%2F20&template=3-help-wanted.yml&title=I+need+help+with...)

[![Share on X](https://img.shields.io/twitter/url?label=Share%20on%20Twitter&style=social&url=https%3A%2F%2Fgithub.com%2Fatapas%2Fmodel-repo)](https://twitter.com/intent/tweet?text=👋%20Check%20this%20amazing%20repo%20https://github.com/mauroalderete/coding-projects-template,%20created%20by%20@_mauroalderete%0A%0A%23DEVCommunity%20%23Coding%20%23DevOps)

&nbsp;

</div>

- [✋ Introducing `coding-projects-templates`](#-introducing-coding-projects-templates)
- [❓ How to use this template](#-how-to-use-this-template)
- [🔥 What to do After Using `coding-projects-templates`](#-what-to-do-after-using-coding-projects-templates)
- [Workflows](#workflows)
  - [CodeQL](#codeql)
  - [Tests](#tests)
  - [Labeling](#labeling)
  - [Liberation](#liberation)
  - [Project Automation](#project-automation)
  - [Deploy Release](#deploy-release)
- [Code of conduct](#code-of-conduct)
- [License](#license)
- [Gitignore](#gitignore)

&nbsp;

## ✋ Introducing `coding-projects-templates`

This repository template contains the essential elements used in various projects to many stacks.

- Includes workflows to handle labeling, versioning, testing, release and deployment.
- Contains a private license, a basic contributing redaction, and a covenant code of conduct.
- Implements a definition to generate release notes.
- Defines templates to the three issues types (bug, features, help wanted) and a pull request template.
- Additional prepare a dependabot script.
- Schedule a CodeQL Analysis.
- And include CODEOWNERS

> Many of the configuration files in this repository are not working yet. Just consist of a sample definition of the configuration. You may adapt these files depending on your objectives. You should pay attention to subsequent indications to know how you do it.

## ❓ How to use this template

To use this template, click the button **Use this template** shown in the upper section on [root of repository](https://github.com/mauroalderete/coding-projects-template), then create a new repository.

Another way is starting the process of creating a new repository and selecting this template in the upper section.

## 🔥 What to do After Using `coding-projects-templates`

This template contains many files. A lot of them require special attention.

Once you create a new repo based on this template, probably you would:

- [ ] Remove or disable the workflows that you are not planning use yet.
- [ ] Update `CODEOWNERS`.
- [ ] Update the `CODE_OF_CONDUCT` email.
- [ ] Update `LICENSE`.
- [ ] Edit the `ISSUE_TEMPLATES`, especially to relink the project reference
- [ ] Configure `pull_request_template`
- [ ] Configure dependabot
- [ ] Update `README.md`
  - [ ] Replace title `coding-projects-template` for the title in your repo.
  - [ ] Update subtitle
  - [ ] After edit workflows, update badgets on header section
  - [ ] After edit ISSUE_TEMPLATES, update links on header section
  - [ ] Remove sections that talk about template

> [!NOTE]
> You can this checklist directly in your first issue to start setup your new repo.

Later, in your repository settings could set some configurations compatible with the mode of work the github workflows included in this template:

- Enable `Allow GitHub Actions to create and approve pull request` in `Settings > Actions > General > Workflow Permissions`.
- Add actions secret `GH_PROJECT_AUTOMATION` in `Settings > Secrets and variables > Actions` with next permissions:
  - [x] repo
    - [x] repo:status
    - [x] repo_deployment
    - [x] public_repo
    - [x] repo:invite
    - [x] security_events
  - [x] admin:org
    - [x] write:org
    - [x] read:org
    - [x] manage_runners:org
  - [x] project
    - [x] read:project
- Restrict PR resolving only merging strategy in `Settings > General > Pull Request`:
  - [x] Allow merge commits
  - [ ] Allow squash merging
  - [ ] Allow rebase merging
- Protect you `main` branch in `Settings > Rules > Rulesets` with:
  - Bypass list:
    - Organization admin
    - Maintain
  - Target
    - Default
  - Branch rules
    - [ ] Restrict creations
    - [ ] Restrict updates
    - [x] Restrict deletions
    - [x] Require Linear history
    - [ ] Require deployments to succeed
    - [ ] Require signed commits *recommended enable*
    - [x] Require a pull request before merging
      - Required approvals: 2 *labeling workflow add should send an approval*
      - [ ] Dismiss stale pull request approvals when new commits are pushed
      - [x] Require review from Code Owners
      - [x] Require approval of the most recent reviewable push
      - [x] Require conversation resolution before merging
    - [x] Require status checks to pass
      - [x] Require branches to be up to date before merging
      - [x] Do not require status checks on creation
      - Status checks that are required
        - Unit tests
        - call-labeling-workflow / Assign and test labels from conventional-commits
    - [x] Block force pushes
    - [ ] Require code scanning results

## Workflows

### CodeQL

`/.github/workflows/codeql-analysis.yml`

This file enables the CodeQL service provided by GitHub. You should provide a language supported.
If your project is not supported, I recommend removing this yaml file.

### Tests

`/.github/workflows/tests.yml`

This workflow is the most complex to configure. This depends highly on your stack and environment.
In some cases, you will probably need to split this workflow into unit and integration tests.
It only contains some steps with a simple message showing you the commands to configure a node test environment.

I recommend you study your case carefully.

### Labeling

`/.github/workflows/labeling.yml`

Include a PR labeling workflow caller. It consumes the reusable workflows stored in [mauroalderete/workflows](https://github.com/mauroalderete/workflows).

### Liberation

`/.github/workflows/liberation.yml`

The versioning workflow contains a caller to the reusable workflow stored in [mauroalderete/workflows](https://github.com/mauroalderete/workflows).

The `liberation` include a simple versioning and release without adds other artifacts. Is ideal to start, but in the most uses cases you would create your unique liberation flow.

We recommend you look how the [reusable liberation workflow works](https://github.com/mauroalderete/workflows/blob/main/.github/workflows/liberation.yml). You can find two reusable workflows that allows configure your liberation resources easily.

### Project Automation

`project-automation` consists in a simple workflow caller job to run [mauroalderete/workflows](https://github.com/mauroalderete/workflows).

For this workflows works correctly you need configure the secret `GH_PROJECT_AUTOMATION` with a **PAT token in classic mode**.

The PAT token must have permissions for:

- [x] repo
  - [x] repo:status
  - [x] repo_deployment
  - [x] public_repo
  - [x] repo:invite
  - [x] security_events
- [x] admin:org
  - [x] write:org
  - [x] read:org
  - [x] manage_runners:org
- [x] project
  - [x] read:project

### Deploy Release

This workflows is a simple demo of how setup a simple deploy release when a new release is published by `liberation` workflow.

For `deploy-release` was triggered is needed that `liberation` runs with a github token different that `secrets.GITHUB_TOKEN`.

## Code of conduct

`/CODE_OF_CONDUCT.md`

This code is based on the covenant code. He is only required to specify an email address to the community to send his messages. Now, this email is [alderete.mauro@gmail.com](mailto:alderete.mauro@gmail.com).

## License

`/LICENSE`

This license is a private personal license redacted by chatGPT. This is only an example. I recommend changing this license to other than to be attached better to your needs.
You can replace it with any Open License offered by GitHub, too.

## Gitignore

`/.gitignore`

This file is empty. Replace the content with what you think is more convenient.