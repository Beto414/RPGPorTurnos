# Jogo de Batalha RPG em C# (Projeto de Estudo de POO)

## Visão Geral

Este projeto é uma aplicação de console desenvolvida em C# como um exercício prático durante meus estudos de **Programação Orientada a Objetos (POO)**. Partindo de um conceito básico de batalha de personagens, o projeto foi expandido com ideias próprias para criar um mini-RPG de texto com mecânicas táticas, múltiplas classes de heróis, um bestiário diversificado e uma estrutura de jogo progressiva.

O objetivo principal foi aplicar e aprofundar o conhecimento nos quatro pilares da POO — **Abstração, Encapsulamento, Herança e Polimorfismo** — em um ambiente prático e criativo, indo além do escopo original do curso.

---

## Arquitetura e Design Patterns

A solução foi projetada com foco em código limpo, manutenibilidade e separação de responsabilidades, utilizando uma arquitetura de classes desacoplada:

-   **`Personagem` (Classe Abstrata):** Serve como a base para todas as unidades do jogo (heróis e inimigos), definindo atributos e comportamentos comuns. Um exemplo claro de **Abstração**.
-   **`Guerreiro`, `Mago`, `Arqueiro` e Classes de Inimigos:** Herdam de `Personagem`, especializando-se com status, habilidades e mecânicas únicas. Demonstração de **Herança**.
-   **`Habilidade` (Classe Abstrata):** Cada habilidade especial (ex: `BolaDeFogo`, `GolpeImpetuoso`) é uma classe separada que herda de `Habilidade`. Isso encapsula a lógica de cada ação e permite que novas habilidades sejam adicionadas facilmente.
-   **Polimorfismo em Ação:** O motor de combate (`ArenaDeBatalha`) interage com uma lista de `Personagem`, chamando métodos como `Atacar()` sem precisar saber o tipo concreto da unidade. Cada classe responde de sua própria maneira, seja com um ataque físico, uma magia ou uma habilidade especial.
-   **Encapsulamento:** O estado interno dos personagens (como `PontosDeVida`) é protegido, sendo modificado apenas através de métodos públicos (`ReceberDano()`, `Curar()`), o que garante a integridade dos dados.
-   **Classes de Gerenciamento:** `GameEngine`, `ArenaDeBatalha`, `Mapa` e `Bioma` orquestram o fluxo do jogo, gerenciando o estado, os turnos de combate e a progressão da narrativa.

---

## Funcionalidades Implementadas

### Sistema de Combate Tático
-   **Combate em Grupo:** Batalhas entre um grupo de 3 heróis controlados pelo jogador contra grupos de inimigos controlados por uma IA simples.
-   **Sistema de Turnos:** Ordem de ação clara, com cada personagem agindo uma vez por rodada.
-   **Ações do Jogador:** Em cada turno, o jogador pode escolher entre `Atacar`, `Defender`, `Usar Habilidade` ou `Usar Poção`.
-   **Sistema de Fraquezas:** Implementado um triângulo de vantagens: Mago > Guerreiro > Arqueiro > Mago.

### Classes e Habilidades
-   **3 Classes de Heróis Jogáveis:**
    -   **Guerreiro (Aragorn):** Focado em dano físico e controle, com um sistema de **Troca de Postura** (Ofensiva, Defensiva, Equilibrada).
    -   **Mago (Gandalf):** Especialista em dano mágico em área e efeitos de status, com um sistema de **Mana** que é regenerada com ataques básicos.
    -   **Arqueiro (Legolas):** Mestre em dano crítico e debuffs, com habilidades de alvo único e em área.
-   **12 Habilidades Únicas:** Cada herói possui 4 habilidades distintas, incluindo ataques poderosos, buffs para aliados e debuffs para inimigos.

### Mundo do Jogo e Progressão
-   **Bestiário com 19 Inimigos:** Inclui **15 inimigos normais** com comportamentos únicos, **3 chefes únicos** no final de cada bioma e **1 chefe final (Sauron)** com múltiplas fases e ataques.
-   **3 Biomas Distintos:** Gelo, Pântano e Deserto. Cada bioma possui 5 tipos de inimigos temáticos.
-   **Estrutura de Jornada:** O jogo progride através de 3 estágios. Cada estágio consiste em 3 batalhas aleatórias seguidas por um **chefe de bioma**.
-   **Narrativa Procedural:** Após cada vitória, um texto narrativo aleatório e único é exibido para dar imersão à jornada.
-   **Sistema de Recursos:** O grupo compartilha um estoque de 3 poções de cura por batalha, e a vida/mana são recuperadas parcialmente após batalhas normais e totalmente após derrotar um chefe.

---

## Tecnologias Utilizadas

-   **Linguagem:** C#
-   **Plataforma:** .NET (Framework ou Core)
-   **Ambiente:** Aplicativo de Console

---

## Como Executar

1.  Clone o repositório.
2.  Abra a solução (`.sln`) no Visual Studio.
3.  Pressione `F5` ou o botão "Iniciar" para compilar e executar o projeto.
4.  A aventura começará no console. Siga as instruções na tela para jogar.
