pipeline {
    agent any

    stages {

        stage('Build') {
            steps {
                bat 'dotnet restore'
                bat 'dotnet build'
            }
        }

        stage('Install Playwright') {
            steps {
                bat 'pwsh bin\\Debug\\net9.0\\playwright.ps1 install chromium'
            }
        }

        stage('Run Tests') {
            steps {
                bat 'dotnet test'
            }
        }
    }
}