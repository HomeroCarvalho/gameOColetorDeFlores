//using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;

	/// <summary>
	/// Gerenciador de niveis. Construir uma nova instancia de objeto toda vez que for preciso.
	/// </summary>
	public class GerenciamentoDeNiveis
	{
		
		public static List<umaMissao> TodosNiveis= new List<umaMissao>();
		
		
		
		/// <summary>
		/// Descricao de uma missao.
		/// </summary>
		/// <returns>a missao especificada em [nivel] e [missao].</returns>
		/// <param name="nivel">Nivel da missao.</param>
		/// <param name="missao">Missao: numero da missao.</param>
        public List<umaMissao> RelacaoDeMissoes()
        {
            FileStream flstrm = new FileStream("missoes.txt", FileMode.Open, FileAccess.Read);
            StreamReader strRdr = new StreamReader(flstrm);
            string umaLinha = "";
            string marcador = ""; 
            int contMetas = 0;
            
            List<string> saudacao = new List<string>();
            List<string> metas = new List<string>();
            List<string> notas = new List<string>();
            List<itemMeta> tags_missao = new List<itemMeta>();
            
            while (!strRdr.EndOfStream)
            {
                umaLinha = strRdr.ReadLine();
                marcador = this.determinaQualTag(umaLinha);
               if (marcador.Equals("FIM_DE_ARQUIVO"))
                   return (TodosNiveis);

                if (marcador.Equals("FIM_NIVEL"))
                {
                    TodosNiveis.Add(new umaMissao(saudacao, metas, notas, tags_missao));
                    saudacao = new List<string>();
                    metas = new List<string>();
                    notas = new List<string>();
                    tags_missao = new List<itemMeta>();
                    contMetas=0;

                }
                if (marcador.Equals("SAUDACAO"))
                    saudacao.Add(devolveTextoSemTag(umaLinha));
                if (marcador.Equals("META"))
                    metas.Add("meta " + (++contMetas) + ": " + devolveTextoSemTag(umaLinha));
                if (marcador.Equals("NOTA"))
                    notas.Add(devolveTextoSemTag(umaLinha));
                if (marcador.Equals("TAG_MISSAO"))
                {
                    string NOME = "";
                    string quant="";
                    string cash="";
                    umaLinha=strRdr.ReadLine();
                    marcador= this.determinaQualTag(umaLinha);
                    if (marcador.Equals("NOME"))
                        NOME=devolveTextoSemTag(umaLinha);
                    umaLinha=strRdr.ReadLine();
                    marcador= this.determinaQualTag(umaLinha);
                    
                    if (marcador.Equals("N."))
                        quant=devolveTextoSemTag(umaLinha);
                    umaLinha=strRdr.ReadLine();
                    marcador= this.determinaQualTag(umaLinha);
                    
                    if (marcador.Equals("R$"))
                        cash=devolveTextoSemTag(umaLinha);
                    tags_missao.Add(new itemMeta(NOME, quant, cash));
                } // if marcador=TAG_MISSAO

            } // while stdr.EndOfStream()
            strRdr.Close();

            return (TodosNiveis);

        }// voNOME RelacaoDeMissoes()

        string devolveTextoSemTag(string umaLinha)
        {
            // retirada de [FIM_NIVEL] porque é um texto sem tag.
            string[] dados = umaLinha.Split(new string[]{"[SAUDACAO]","[META]",
				"[NOTA]","[TAG_MISSAO]","[NOME]","[N.]","[R$]"}, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                return (dados[0]);
            }
            catch
            {
                return ("ERRO NO ARQUIVO DE MISSAO");
            }
            
        }
        string determinaQualTag(string umalinha)
        {
            string[] dados = umalinha.Split(new string[]{"[SAUDACAO]","[META]",
				"[NOTA]","[TAG_MISSAO]","[NOME]","[N.]","[R$]","[FIM_NIVEL]","[FIM_DE_ARQUIVO]"}, StringSplitOptions.RemoveEmptyEntries);

            string[] marcadores = umalinha.Split(dados, StringSplitOptions.RemoveEmptyEntries);
            if (marcadores[0].Equals("[SAUDACAO]"))
                return ("SAUDACAO");
            if (marcadores[0].Equals("[META]"))
                return ("META");
            if (marcadores[0].Equals("[NOTA]"))
                return ("NOTA");
            if (marcadores[0].Equals("[TAG_MISSAO]"))
                return ("TAG_MISSAO");
            if (marcadores[0].Equals("[NOME]"))
                return ("NOME");
            if (marcadores[0].Equals("[N.]"))
                return ("N.");
            if (marcadores[0].Equals("[R$]"))
                return ("R$");
            if (marcadores[0].Equals("[FIM_NIVEL]"))
                return ("FIM_NIVEL");
            if (marcadores[0].Equals("[FIM_DE_ARQUIVO]"))
                return ("FIM_DE_ARQUIVO");
            return ("ERRO NO ARQUIVO DE MISSOES");

        } // determinaQualTag
		
			
	} // classe GerenciadorDeNiveis
	
	/// <summary>
	/// classe para guardar qualquer tipo de item para estabelecer a meta.
	/// </summary>
	public class itemMeta
	{
		public string nomeDoObjeto;
		public string quant;
		public string cash;
		
		
		public itemMeta(string nome, string quantity, string moneyUnitaryItem)
		{
			this.nomeDoObjeto=nome;
			this.quant=quantity;
			this.cash=moneyUnitaryItem;
		} // construtor

        public override string ToString()
        {
            string s = "";
            s += "nome do objeto: " + nomeDoObjeto + "  quantidade: " + quant + " dinheiro pago: " + cash;
            return (s);
        }
		
	} // class itemMeta
	
	/// <summary>
	/// descreve uma missao ao jogador, com saudacoes, metas e notas (observacoes);
	/// </summary>
    public class umaMissao
    {
        public string[] Saudacao;
        public string[] metas;
        public string[] notas;
        public itemMeta[] tags_missao;

        public umaMissao()
        {

        }

        public umaMissao(List<string> saudacoes,
                         List<string> asMetas,
                         List<string> asNotas,
                         List<itemMeta> astags_missao)
        {

            this.Saudacao = saudacoes.ToArray();
            this.metas = asMetas.ToArray();
            this.notas = asNotas.ToArray();
            this.tags_missao = astags_missao.ToArray();
        }

        public override string  ToString()
        {
 	        int i;
            string s="";
            for (i=0;i<this.Saudacao.Length;i++)
                s+=this.Saudacao[i]+"\n";
            for (i=0;i<this.metas.Length;i++)
                s+=this.metas[i]+"\n";
            for (i=0;i<this.notas.Length;i++)
                s+=this.notas[i]+"\n";
            for (i = 0; i < this.tags_missao.Length; i++)
                s += this.tags_missao[i].ToString() + "\n";
            return (s);
        }

    } // class umaMissao
	
	
	
