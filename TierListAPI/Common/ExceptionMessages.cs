namespace TierListAPI.Common.ExceptionMessages;

public static class ExceptionMessage
{
    public static class BadRequest
    {
        public const string Default = "Bad request.";
    }

    public static class Ok
    {
        public const string Default = "Operação concluída com sucesso.";
    }

    public static class DuplicityModel
    {
        public const string Default = "Esse valor já existe.";
        public const string Item = "Já existe um item com esse nome, escolha outro.";
        public const string Tag = "Já existe uma tag com esse nome, escolha outro.";
        public const string Tier = "Já existe um tier com esse nome, escolha outro.";
        public const string TierListTemplate = "Já existe uma Tier List com esse nome, escolha outro.";
        public const string User = "Já existe um usuário com esse nome, escolha outro.";
        public const string UserAnswer = "Foi encontrada uma resposta sua desse item nesse tier.";
    }

    public static class InternalServerError
    {
        public const string Default = "Erro interno";
    }

    public static class NotFound
    {
        public const string Default = "O item não foi encontrado.";
        public const string Item = "Item não encontrado.";
        public const string Submission = "O grupo de respostas não foi encontrado.";
        public const string Tag = "A tag não foi encontrada.";
        public const string Tier = "O Tier não foi encontrado.";
        public const string TierListTemplate = "O template da Tier List não foi encontrado.";
        public const string User = "O usuário não foi encontrado.";
        public const string UserAnswer = "A resposta do usuário não foi encontrada.";
    }

    public static class Unauthorized
    {
        public const string Default = "Você não possui autorização.";
        public const string Session = "Sessão inválida, por favor, faça login";
        public const string Token = "Token inválido.";
        public const string TokenPrefix = "Token must be Bearer type.";
        public const string Credentials = "Credenciais incorretas.";
    }

    public static class Forbidden
    {
        public const string Default = "Você não possui permissão para fazer essa ação.";
    }
}