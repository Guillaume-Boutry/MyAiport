pipeline {
  agent any
  stages {
    stage('Build EF') {
      steps {
        sh 'dotnet build MyAirport.EF'
      }
    }

    stage('Build WebApi') {
      parallel {
        stage('Build WebApi') {
          steps {
            sh 'MyAirport.WebApi'
          }
        }

        stage('Build ConsoleApp') {
          steps {
            sh 'dotnet build MyAirport.ConsoleApp'
          }
        }

      }
    }

    stage('Test WebApi') {
      steps {
        sleep 1
      }
    }

  }
}