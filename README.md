# KubernetesExample

## Lista de Comandos

### Instalação
- function kubectl { minikube kubectl -- $args }

### Pushing images(usando o docker daemon dentro do minikube)
- & minikube -p minikube docker-env --shell powershell | Invoke-Expression

### Deploy
- kubectl get deployments
- kubectl apply --filename deployment.yaml
- kubectl delete --filename deployment.yaml
- kubectl logs kubernetes-example-6f854df45b-9drjj

## Outros
- docker build --tag app1 ./app1
- docker build --tag app2 ./app2