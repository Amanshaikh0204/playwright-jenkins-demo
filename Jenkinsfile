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
                catchError(buildResult: 'SUCCESS', stageResult: 'UNSTABLE') {
                    bat 'dotnet test -- NUnit.TestOutputXml=TestResults'
                }
            }
        }

        stage('Publish Test Results') {
            steps {
                nunit testResultsPattern: 'bin/Debug/net9.0/TestResults/*.xml'
            }
        }
    }

    post {
        always {
            archiveArtifacts artifacts: 'bin/Debug/net9.0/TestResults/Screenshots/**/*.png',
                             allowEmptyArchive: true
        }
    }
}