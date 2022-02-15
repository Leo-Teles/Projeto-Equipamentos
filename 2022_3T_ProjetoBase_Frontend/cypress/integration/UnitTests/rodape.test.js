//Metodo de teste - describe('descrição', funcao a ser execuuada)

describe('Componente - Rodapé', () => {

    //Pré condição 

    // abrir o navegador 
    beforeEach(() => {
        cy.visit('http://localhost:3000');
    })


    // Descrição
    it('Deve existir uma tag footer no corpo do documento', () => {

        cy.get('footer').should('exist')

    })

    it('deveconter texto senai Informatica', () => {

        cy.get('.rodapePrincipal section div p').should('have.text','Escola SENAI de Informática - 2021')

    })

    it('Deve verificar se footer está visivel e se possui uma classe chamada rodapeprincical', () => {

        cy.get('footer').should('be.visible').and('have.class', 'rodapePrincipal')

    })

})