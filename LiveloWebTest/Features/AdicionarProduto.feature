Funcionalidade: Adicionar um produto ao carrinho

Como um Product Owner
Eu quero que um Visitante possa comprar produtos usando diferentes plataformas do site
Para que possa aumentar a exposição do portifolio de produtos dos parceiros

Contexto: 
	Dado a página principal da livelo foi carregada com sucesso

@automated
@done
Cenário: Visitante adiciona um produto do mostruário
	Dado Diogo selecionou o Primeiro produto do mostruário
	Quando Diogo adiciona o produto ao carrinho
	Então o carrinho deverá apresentar 1 produto
	E o carrinho deverá apresentar os detalhes do(s) produto(s) selecionado(s)
	
@automated
@done
Cenário: Visitante adiciona um produto pela pesquisa
	Dado Diogo pesquisou o produto Ferro a Vapor com as características:
	| Categoria              | Intervalo de preços     | Marca                |
	| Casa, Eletrodomesticos | 10.000 pts - 20.000 pts | Arno, Black & Decker |
	E Diogo selecionou o Primeiro produto da pesquisa
	Quando Diogo adiciona o produto ao carrinho
	Então o carrinho deverá apresentar 1 produto
	E o carrinho deverá apresentar os detalhes do(s) produto(s) selecionado(s)

#Todos os cenários abaixo só podem ser executados manualmente ,pois não tenho controle sobre a imagem/dados de produção, uma vez que a estratégia
#de execução são testes integrados. As pré-condições de criação de massa DEVEM ser elaboradas FORA do tempo de execução de testes, ou seja uma imagem deve conter os pontos de partida dos respectivos cenários abaixo. 
#Não é uma boa prática criar um item no Given para depois "remover" o item no WHEN, conforme já explicado acima.
@manual
@planned
Cenário: Visitante adiciona um produto conhecido

@manual
@planned
Cenário: Visitante adiciona um produto que sofreu uma alteração

@manual
@planned
Cenário: Visitante adiciona o mesmo produto ao carrinho

@manual
@planned
Cenário: Visitante remove todos os produtos do carrinho

@manual
@planned
Cenário: Visitante remove uma quantidade do mesmo produto

@manual
@planned
Cenário: Visitante adiciona uma quantidade do mesmo produto

@manual
@planned
Cenário: Visitante acessa o carrinho vazio

@manual
@planned
Esquema do Cenário: Visitante altera um produto que sofreu uma alteração