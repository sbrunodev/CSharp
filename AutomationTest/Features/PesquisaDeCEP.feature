Feature: PesquisaDeCEP
	Pesquisar diferentes CEPs e Rastreamentos validando se os mesmos existem ou não.

@mytag
Scenario: Pesquisar Ceps
	Given Estou no site dos correios
	Then Procure pelo CEP 80700000
	Then Confirme que o CEP não existe
	Then Volte a tela inicial
	Then Procure pelo CEP 01013-001
	Then Confirmar que o resultado seja em "Rua Quinze de Novembro, São Paulo/SP"
	Then Volte a tela inicial
	Then Procurar no rastreamento de código o número "SS987654321BR"
	Then Confirmar que o código não está correto
	Then Fechar o Browser

