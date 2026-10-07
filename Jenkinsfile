pipeline {
    agent any

    stages {

        stage('Build Docker Image') {
            steps {
                bat 'docker build -t playwright-qa .'
            }
        }

        stage('Run Playwright Tests') {
            steps {
                bat 'docker run --rm playwright-qa'
            }
        }
    }
}